<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Catalogo.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container-fluid">
                <h1 class="mb-4 mt-3">Lista de Productos</h1>
                <asp:Label ID="Labelfiltro" runat="server" Text="Buscar"></asp:Label>
                <asp:TextBox ID="filtro" OnTextChanged="filtro_TextChanged" CssClass="mb-5 input-group-lg" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>
            <asp:GridView ID="dgvProductos" CssClass="table table-striped table-sm table-bordered container" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                </Columns>
            </asp:GridView>
     


</asp:Content>
