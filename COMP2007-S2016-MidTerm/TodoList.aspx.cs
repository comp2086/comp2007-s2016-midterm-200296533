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
                grdTodoList.DataSource = todos.AsQueryable().OrderBy(SortString).ToList();
                grdTodoList.DataBind();

            }
        }

        protected void grdTodoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdTodoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdTodoList_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdTodoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}