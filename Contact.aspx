<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>.
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"   >
                                <asp:ListItem value ="0" Selected ="True"  >Agregar</asp:ListItem>
                                <asp:ListItem value ="1" >Modificar</asp:ListItem>
                                <asp:ListItem value ="2" >Eliminar</asp:ListItem>
                            </asp:RadioButtonList>
        
    </p>
    <p>

        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="View1" runat="server">
  
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Agregar" />
            </asp:View>
            <asp:View ID="View2" runat="server">

                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Mofificar" OnClick="Button2_Click" />

            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Eliminar" OnClick="Button3_Click" />
            </asp:View>
        </asp:MultiView>
         <p>
                <asp:Label ID="Label1" runat="server" Text="Label">Nombre: </asp:Label>
                <asp:TextBox ID="txt_nombre" runat="server" Width="516px"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label">Apellido: </asp:Label>
                &nbsp;:
                <asp:TextBox ID="txt_apellido" runat="server" Width="510px"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Label">D.N.I.: </asp:Label>
                &nbsp;:<asp:TextBox ID="txt_dni" runat="server" Width="529px"></asp:TextBox>
                <br />
             <asp:Label ID="Label4" runat="server" Text="Label">FechaNacimiento: </asp:Label>
                <asp:TextBox ID="txt_fecha" runat="server" Width="452px" TextMode="Date"></asp:TextBox>
         </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SQLsever_ejemplo01">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="nomre" HeaderText="nomre" SortExpression="nomre" />
            <asp:BoundField DataField="apellido" HeaderText="apellido" SortExpression="apellido" />
            <asp:BoundField DataField="dni" HeaderText="dni" SortExpression="dni" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SQLsever_ejemplo01" runat="server" ConnectionString="<%$ ConnectionStrings:basedatos_ejemplo01 %>" SelectCommand="SELECT * FROM [Persona]"></asp:SqlDataSource>
    </p>




</asp:Content>
