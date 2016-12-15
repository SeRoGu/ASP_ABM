using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : Page
{
    public DatoPersona datos = new DatoPersona();
    protected void Page_Load(object sender, EventArgs e)
    {

        //MultiView1.ActiveViewIndex = 0;
        GridView1.DataBind();
        actualizarListas();
        actualizarTextBox();

    }



    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

        if (MultiView1.ActiveViewIndex == 0)
        {
            txt_apellido.Enabled = true;
            txt_nombre.Enabled = true;
            txt_dni.Enabled = true;
            txt_fecha.Enabled = true;
        }
        else if (MultiView1.ActiveViewIndex == 1)
        {
            txt_apellido.Enabled = true;
            txt_nombre.Enabled = true;
            txt_dni.Enabled = true;
            txt_fecha.Enabled = true;

        }
        else if (MultiView1.ActiveViewIndex == 2)
        {
            txt_apellido.Enabled = false;
            txt_nombre.Enabled = false;
            txt_dni.Enabled = false;
            txt_fecha.Enabled = false;
        }
        actualizarListas();
    }
    protected void actualizarListas()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        datos.actualizar_tabla();
        foreach (Row_Persona nodo in datos.tabla)
        {
            DropDownList1.Items.Add(nodo.id.ToString());
            DropDownList2.Items.Add(nodo.id.ToString());
        }

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Row_Persona nodoAux = new Row_Persona();
        nodoAux.apellido = txt_apellido.Text;
        nodoAux.nombre = txt_nombre.Text;
        nodoAux.dni = Convert.ToInt32(txt_dni.Text);
        string dateAux2 = String.Format("{0: yyyy-MM-dd}", txt_fecha.Text);
        // DateTime dateAux3 =  Convert.ToDateTime(String.Format("{0:yyyy-mm-dd }", txt_fecha.Text));
        // nodoAux.fecha = DateTime.ParseExact(dateAux2, "yyyy-MM-dd", null); ;
        nodoAux.fecha = dateAux2;
        datos.insertar_tabla(nodoAux);
        GridView1.DataBind();
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        Row_Persona nodoAux = new Row_Persona();
        nodoAux.apellido = txt_apellido.Text;
        nodoAux.nombre = txt_nombre.Text;
        nodoAux.dni = Convert.ToInt32(txt_dni.Text);
        nodoAux.fecha = String.Format("{0: yyyy-MM-dd}", txt_fecha.Text); //Convert.ToDateTime(String.Format("{0: yyyy-MM-dd}", txt_fecha.Text)   ); // Convert.ToDateTime(String.Format("{0:d/M/yyyy HH:mm:ss}", txt_fecha.Text)   );
        nodoAux.id = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        datos.update_tabla(nodoAux);
        GridView1.DataBind();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Row_Persona nodoAux = new Row_Persona();
        nodoAux.id = Convert.ToInt32(DropDownList2.SelectedItem.Value);
        datos.eliminar_tabla(nodoAux);
        GridView1.DataBind();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.Items[0].Selected == true)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        else if (RadioButtonList1.Items[1].Selected == true)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        else if (RadioButtonList1.Items[2].Selected == true)
        {
            MultiView1.ActiveViewIndex = 2;
        }
        GridView1.DataBind();
    }
    protected void actualizarTextBox()
    {

        if (RadioButtonList1.Items[0].Selected == true)
        {

        }
        else if (RadioButtonList1.Items[1].Selected == true)
        {
            Row_Persona row = (Row_Persona)datos.tabla[DropDownList1.SelectedIndex];
            txt_apellido.Text = row.apellido;
            txt_nombre.Text = row.nombre;
            txt_dni.Text = row.dni.ToString();
            txt_fecha.Text = row.fecha;


        }
        else if (RadioButtonList1.Items[2].Selected == true)
        {
            Row_Persona row = (Row_Persona)datos.tabla[DropDownList2.SelectedIndex];
            txt_apellido.Text = row.apellido;
            txt_nombre.Text = row.nombre;
            txt_dni.Text = row.dni.ToString();
            txt_fecha.Text = row.fecha;

        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        actualizarTextBox();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        actualizarTextBox();
    }

}