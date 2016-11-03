using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                // check the url for an id so we know if we are adding or editing
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    // get id from the url
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    // connect
                    var conn = new ContosoEntities();

                    // look up the selected student
                    var objStd = (from s in conn.Students
                                  where s.StudentID == StudentID
                                  select s).FirstOrDefault();

                    // populate the form
                    txtFirstName.Text = objStd.FirstMidName;
                    txtLastName.Text = objStd.LastName;
                    eTxtDate.Text = objStd.EnrollmentDate.ToString();
                }
            }


            eTxtDate.Text = Convert.ToString(eCal.TodaysDate);
            eCal.Visible = false;

        }

        // Button for pop-up calendar
        protected void btnCal_Click(object sender, EventArgs e)
        {
            if (eCal.Visible == false)
            {
                eCal.Visible = true;
            }
            else if (eCal.Visible == true)
            {
                eCal.Visible = false;
            }
        }

        //Method to Fill the eTxtDate field when date is selected from the calendar
        protected void eCal_SelectionChanged(object sender, EventArgs e)
        {
            eTxtDate.Text = Convert.ToString(eCal.SelectedDate);
        }

        // When save button is clicked connect to DB and save the values to DB
        protected void btnSave_Click(object sender, EventArgs e)
        {

            //connect the db
            var conn = new ContosoEntities();

            //use the Student class to create a new Student object from student.cs
            Student s = new Student();

            //fill the properties of the new student object
            s.FirstMidName = txtFirstName.Text;
            s.LastName = txtLastName.Text;
            s.EnrollmentDate = Convert.ToDateTime(eTxtDate.Text);

            //save a new object to db
            conn.Students.Add(s);
            conn.SaveChanges();

            //redirect to the student page
            Response.Redirect("students.aspx");
        }
    }
}