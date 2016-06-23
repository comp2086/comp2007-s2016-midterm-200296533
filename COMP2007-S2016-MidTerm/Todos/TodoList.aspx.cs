using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "TodoName"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the student data
                GetTodos();
            }
        }

        protected void GetTodos()
        {
            using (TodoConnection db = new TodoConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Students Table using EF and LINQ
                var todos = (from _todos in db.Todos
                             select _todos);

                // bind the result to the GridView
                TodoGridView.DataSource = todos.AsQueryable().OrderBy(SortString).ToList();
                TodoGridView.DataBind();

            }
        }

        protected void TodoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TodoGridView.PageIndex = e.NewPageIndex;

            GetTodos();
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected StudentID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF to find the selected student in the DB and remove it
            using (TodoConnection db = new TodoConnection())
            {
                // create object of the Student class and store the query string inside of it
                Todo deletedTodo = (from todos in db.Todos
                                    where todos.TodoID == TodoID
                                    select todos).FirstOrDefault();

                // remove the selected student from the db
                db.Todos.Remove(deletedTodo);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetTodos();
            }
        }

        protected void TodoGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            var prevSortColumn = Session["SortColumn"].ToString();
            var nextSortColumn = e.SortExpression;

            if (prevSortColumn == nextSortColumn)
            {
                // Just toggle the direction
                Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }

            // Save the new sort column
            Session["SortColumn"] = nextSortColumn;

            // Redirect to the first page
            TodoGridView.PageIndex = 0;

            // Refresh the Grid
            GetTodos();
        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < TodoGridView.Columns.Count - 1; index++)
                    {
                        if (TodoGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }

        protected void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            // Get the clicked checkbox
            CheckBox chk = (CheckBox)sender;

            // Get the row 
            GridViewRow gvr = (GridViewRow)chk.NamingContainer;
            var selectedRow = gvr.RowIndex;

            // get the selected StudentID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            // Create a new Todo item
            Todo newTodo = new Todo();


            using (TodoConnection db = new TodoConnection())
            {
                // get the current student from EF DB
                newTodo = (from todo in db.Todos
                           where todo.TodoID == TodoID
                           select todo).FirstOrDefault();

                newTodo.Completed = chk.Checked;

                try
                {
                    db.SaveChanges();
                    Response.Redirect("/Todos/TodoList.aspx");
                }
                catch (Exception ex)
                {
                    // ...
                }
            }
        }

        protected void btnAddTodo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Todos/TodoDetails.aspx");
        }

        /**
         * <summary>
         * This event handler adjusts the pagesize of the todo list
         * </summary>
         * 
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void ddlTodoListPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageSize = Convert.ToInt32(ddlTodoListPageSize.SelectedValue);

            TodoGridView.PageSize = pageSize;

            GetTodos();
        }
    }
}