<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdTodoList" runat="server"
        CssClass="table table-bordered table-striped table-hover"
        AutoGenerateColumns="false" DataKeyNames="TodoID"
        OnRowDeleting="grdTodoList_RowDeleting" AllowPaging="true" PageSize="3"
        OnPageIndexChanging="grdTodoList_PageIndexChanging" AllowSorting="true"
        OnSorting="grdTodoList_Sorting" OnRowDataBound="grdTodoList_RowDataBound"
        PagerStyle-CssClass="pagination-ys">
        <Columns>
            <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="false" SortExpression="TodoID" />
            <asp:BoundField DataField="TodoName" HeaderText="Todo Name" Visible="true" SortExpression="TodoName" />
            <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true" SortExpression="TodoNotes" />
            <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                NavigateUrl="~/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
        </Columns>
    </asp:GridView>
</asp:Content>
