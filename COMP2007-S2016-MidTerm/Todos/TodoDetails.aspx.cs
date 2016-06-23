/**
 * Todo List App
 * By: Alex Andriishyn
 * TodoDetails Page Code Behind file
 * http://comp2007-s2016-midterm-200296533.azurewebsites.net/
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm.Models;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                GetTodo();
            }
        }

        /**
         * <summary>
         * This method gets a todo from the DB
         * </summary>
         * 
         * @returns {void}
         */
        protected void GetTodo()
        {
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a todo object instance with the TodoID from the URL Parameter
                Todo updatedTodo = (from todo in db.Todos
                                          where todo.TodoID == TodoID
                                          select todo).FirstOrDefault();

                // map the todo properties to the form controls
                if (updatedTodo != null)
                {
                    txtTodoName.Text = updatedTodo.TodoName;
                    txtTodoNotes.Text = updatedTodo.TodoNotes;
                    chkCompleted.Checked = (bool) updatedTodo.Completed;
                }
            }
        }

        /**
         * <summary>
         * This event handler saves a new todo/edits an existing one
         * </summary>
         * 
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new Todo item
            Todo newTodo = new Todo();

            int TodoID = 0;
            
            // Save the new Todo item to the DB
            using (TodoConnection db = new TodoConnection())
            {
                // Editing an existing todo
                if (Request.QueryString.Count > 0)
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current student from EF DB
                    newTodo = (from todo in db.Todos
                                  where todo.TodoID == TodoID
                                  select todo).FirstOrDefault();
                }

                newTodo.Completed = chkCompleted.Checked;
                newTodo.TodoName = txtTodoName.Text;
                newTodo.TodoNotes = txtTodoNotes.Text;

                try
                {
                    if (TodoID == 0)
                    {
                        db.Todos.Add(newTodo);
                    }

                    db.SaveChanges();
                    Response.Redirect("~/Todos/TodoList.aspx");
                }
                catch (Exception ex)
                {
                    // ...
                }
            }
        }

        /**
         * <summary>
         * This event handler redirects to the default page
         * </summary>
         * 
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}