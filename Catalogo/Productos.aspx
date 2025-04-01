<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Catalogo.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <asp:GridView ID="dgvProductos"   CssClass="table table-striped table-sm table-bordered container" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText ="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText ="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText ="Marca" DataField="Marca" />
                <asp:BoundField HeaderText ="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText ="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>
       
   
</asp:Content>
