﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StnwServiceWeb;

public partial class samplew01 : System.Web.UI.Page
{
    public DataSet dst;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind the GridView with data from the DataSet
            dst = GetData();
            ViewState["UserData"] = dst; // Store the dataset in ViewState
            GridView1.DataSource = dst.Tables["Users"];
            GridView1.DataBind();
        }
        else
        {
            // Retrieve the dataset from ViewState on postback
            dst = (DataSet)ViewState["UserData"];
        }
    }

    private DataSet GetData()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(new DataTable("Users"));
        DataTable dt = ds.Tables["Users"];
        dt.Columns.Add("Id", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Town", typeof(string));
        dt.Columns.Add("Country", typeof(string));
        dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };

        dt.Rows.Add("ABDEN", "Maria Weiss", "Berlin", "Germany");
        dt.Rows.Add("AXEIS", "Pedro Alvarez", "México D.F.", "Mexico");
        dt.Rows.Add("BENOI", "Anna Tóth", "Szeged", "Hungary");
        dt.Rows.Add("CAZLE", "Jan Eriksson", "Mannheim", "Sweden");
        dt.Rows.Add("DRFOS", "Giulia Donatelli", "Milano", "Italia");
        return ds;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        clsStnwClassWeb tsi = new clsStnwClassWeb();
        tsi.dsRPT = dst;

        tsi.preslAccountCode = "DEMO1";  // your account code
        tsi.preslUserCode = "0000";  // yout user code

        string binPath = HttpContext.Current.Server.MapPath("~/bin");
        tsi.ReportFullName = System.IO.Path.Combine(binPath, "CustomerReport1.rpt");

        tsi.ShowWindow(this, HttpContext.Current);
    }

}

