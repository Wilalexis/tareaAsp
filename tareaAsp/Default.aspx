<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tareaAsp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Formulario empelado</h1>
    <p>
            
        <asp:Label ID="carnet" runat="server" Text="Carnet" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="carne" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label1" runat="server" Text="Nombres" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="nombres" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="Apellidos" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="apellidos" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text="Direccion" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="direccion" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Telefono" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="telefono" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label5" runat="server" Text="Correo" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="correo" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label6" runat="server" Text="Tipo de sangre" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:DropDownList ID="drop_sangre" runat="server" CssClass="form-control"></asp:DropDownList>     
        <asp:Label ID="Label7" runat="server" Text="Fecha_nacimiento" CssClass="form-control-static input-lg"></asp:Label> 
        <asp:TextBox ID="fecha_nan" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

        <div class="btn-group" role="group" aria-label="Basic mixed styles example">
            <asp:Button ID="agregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="agregar_Click"/>
            <asp:Button ID="modicar" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="modicar_Click" Visible="False" />
            
        </div>

        <asp:Label ID="mensaje" runat="server" CssClass="form-control-static input-lg"></asp:Label> 

        <br />

        <asp:GridView ID="grid_datos" runat="server" AutoGenerateColumns="False" CssClass="table-hover" DataKeyNames="id,sangre" OnRowDeleting="grid_datos_RowDeleting" OnSelectedIndexChanged="grid_datos_SelectedIndexChanged1">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="Ver" CssClass="btn btn-info"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" CssClass="btn btn-danger"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="carne" HeaderText="Carne" />
                <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="correo_electronico" HeaderText="Correo" />
                <asp:BoundField DataField="sangre" HeaderText="Tipo de sangre" />
                <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de nacimiento" DataFormatString="{0:d}" />
            </Columns>
    </asp:GridView>
              
    
</asp:Content>
