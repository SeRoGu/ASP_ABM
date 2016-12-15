using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for DatoPersona
/// </summary>
/// 
public class Row_Persona
{

    public int id { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public int dni { get; set; }
    public string fecha { get; set; }

}
public class DatoPersona
{
    SqlConnection con;
    public System.Collections.ArrayList tabla = new System.Collections.ArrayList();
    public void actualizar_tabla()
    {
        try
        {
            tabla.Clear();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;  //directo de web.config

            using (con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT ID, nomre ,apellido ,dni, date FROM Persona", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Row_Persona obj = new Row_Persona();


                        if (!reader.IsDBNull(0))
                        {
                            obj.id = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.nombre = reader.GetString(1);
                            }
                            else
                            {
                                obj.nombre = "";
                            }

                            if (!reader.IsDBNull(2))
                            {
                                obj.apellido = reader.GetString(2);
                            }
                            else
                            {
                                obj.apellido = "";
                            }

                            if (!reader.IsDBNull(3))
                            {
                                obj.dni = reader.GetInt32(3);
                            }
                            else
                            {
                                obj.dni = 0;
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.fecha = String.Format("{0: yyyy-MM-dd}", reader.GetDateTime(4)); ;
                            }
                            else
                            {
                                obj.fecha = "";
                            }



                            tabla.Add(obj);
                        }

                    }


                }

            }



        }
        catch (SqlException e1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR ");

        }

    }






    public Boolean eliminar_tabla(Row_Persona nodoAux)
    {
        Boolean resultado = false;
        try
        {
            tabla.Clear();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;  //directo de web.config

            using (con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM sentencias  WHERE ID ='" + nodoAux.id + "' ", con))
                {
                    int responder = command.ExecuteNonQuery();
                    if (responder > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
                con.Close();
            }

        }
        catch (SqlException e1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR ");

        }
        return resultado;
    }
    public Boolean update_tabla(Row_Persona nodoAux)
    {
        Boolean resultado = false;
        try
        {
            tabla.Clear();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;  //directo de web.config

            using (con = new SqlConnection(cs))
            {
                con.Open();
                String strDate = nodoAux.fecha;
                string textoCmd = "UPDATE  Persona SET nomre ='" + nodoAux.nombre + "' , apellido = '" + nodoAux.apellido + "' , dni = '" + nodoAux.dni + "' , date = '" + strDate + "' WHERE ID ='" + nodoAux.id + "' ";

                using (SqlCommand command = new SqlCommand(textoCmd, con))
                {
                    int responder = command.ExecuteNonQuery();

                    if (responder > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }


                }
                con.Close();
            }

        }
        catch (SqlException e1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR ");

        }
        return resultado;

    }







    public Boolean insertar_tabla(Row_Persona nodoAux)
    {
        Boolean resultado = false;
        try
        {
            tabla.Clear();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;  //directo de web.config

            using (con = new SqlConnection(cs))
            {
                con.Open();


                string textoCmd = "INSERT INTO Persona ( nomre , apellido , dni , date  ) VALUES (' " + nodoAux.nombre + "' , '" + nodoAux.apellido + "' ,  '" + nodoAux.dni + "' , '" + nodoAux.fecha + " ' ) ";

                using (SqlCommand command = new SqlCommand(textoCmd, con))
                {
                    int responder = command.ExecuteNonQuery();

                    if (responder > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }


                }
                con.Close();
            }

        }
        catch (SqlException e1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR ");

        }
        return resultado;

    }






    public DatoPersona()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}