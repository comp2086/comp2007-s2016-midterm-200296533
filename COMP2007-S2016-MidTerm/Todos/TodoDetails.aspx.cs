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
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new Todo item
            Todo newTodo = new Todo();
            
            newTodo.Completed = false;
            newTodo.TodoName = txtTodoName.Text;
            newTodo.TodoNotes = txtTodoNotes.Text;
            
            // Save the new Todo item to the DB
            using (TodoConnection db = new TodoConnection())
            {
                try
                {
                    db.Todos.Add(newTodo);
                    db.SaveChanges();
                    Response.Redirect("~/Todos/TodoList.aspx");
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}