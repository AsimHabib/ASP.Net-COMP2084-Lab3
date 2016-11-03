using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// add references to access the database
using System.Web.ModelBinding;

namespace Lab3
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the student and dispaly in the grib view
            getStudents();

        }
        protected void getStudents()
        {
            // connect to db
            var conn = new ContosoEntities();

            // run the query using LINQ
            var Students = from s in conn.Students
                           select s;

            // display query result in gridview
            grdStudents.DataSource = Students.ToList();
            grdStudents.DataBind();

        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Fuunction to delete Student fom the gridview
            //1. determine which row in the grid  the user clicked
            Int32 gridIndex = e.RowIndex;

            //2.find the StudentID value in the selected row
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[gridIndex].Value);

            //3. connect to db
            var conn = new ContosoEntities();

            //4.delete the selected student
            Student s = new Student();
            s.StudentID = StudentID;
            conn.Students.Attach(s);
            conn.Students.Remove(s);
            conn.SaveChanges();

            //5. refreh the grid
            getStudents();

        }
    }
}