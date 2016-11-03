using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.ModelBinding;

namespace Lab3
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the department and dispaly in the grib view
            getDepartments();

        }

        protected void getDepartments()
        {
            // connect to db
            var conn = new ContosoEntities();

            // run the query using LINQ
            var Departments = from d in conn.Departments
                              select d;

            // display query result in gridview
            grdDepartments.DataSource = Departments.ToList();
            grdDepartments.DataBind();

        }

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Fuunction to delete Department fom the gridview
            //1. determine which row in the grid  the user clicked
            Int32 gridIndex = e.RowIndex;

            //2.find the DepartmentID value in the selected row
            Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[gridIndex].Value);

            //3. connect to db
            var conn = new ContosoEntities();

            //4.delete the selected department
            Department d = new Department();
            d.DepartmentID = DepartmentID;
            conn.Departments.Attach(d);
            conn.Departments.Remove(d);
            conn.SaveChanges();

            //5. refreh the grid
            getDepartments();

        }
    }

}