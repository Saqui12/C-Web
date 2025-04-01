<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="row row-cols-1 row-cols-md-5 g-4 container">

      <asp:Repeater ID="repeater1" runat="server">
         <ItemTemplate>
                <div class="col">
                <div class="card h-100">
                        <img src=<%# Eval("ImagenUrl") %> class="card-img-top " style="height: 200px; object-fit: contain;" alt="...">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <div class="row row-cols-1 row-cols-md-2 g-4  mt-auto ">
                                <a href="#" class="btn btn-danger "> <i class="bi bi-heart"></i></a>
                                <a href="#" class="btn btn-primary ">Detalles</a>
                            </div>
                            
                        </div>
                </div>
                </div>
         </ItemTemplate>
      </asp:Repeater>

    </div>
</asp:Content>
