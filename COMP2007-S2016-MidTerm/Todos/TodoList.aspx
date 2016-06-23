<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- 
        Todo List App
        By: Alex Andriishyn
        TodoList Page file
        http://comp2007-s2016-midterm-200296533.azurewebsites.net/
        -->
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Todo List</h2>
            </div>
            <div class="col-md-8 col-md-offset-2">
                <h4>Total Todos: <asp:Label ID="lblTotalTodos" runat="server" Text="Label"></asp:Label></h4>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnAddTodo" CssClass="btn btn-success" runat="server" Text="+ Add Todo" OnClick="btnAddTodo_Click" />
                </div>
                <div class="btn-group pull-right" role="group">
                    <asp:Label ID="lblPageSize" runat="server" Text="Page Size: " Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="ddlTodoListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTodoListPageSize_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="All" Value="9999"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
                <asp:GridView ID="TodoGridView" runat="server"
                    CssClass="table table-bordered table-striped table-hover"
                    AutoGenerateColumns="false" DataKeyNames="TodoID"
                    OnRowDeleting="TodoGridView_RowDeleting" AllowPaging="true" PageSize="3"
                    OnPageIndexChanging="TodoGridView_PageIndexChanging" AllowSorting="true"
                    OnSorting="TodoGridView_Sorting" OnRowDataBound="TodoGridView_RowDataBound"
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="false" SortExpression="TodoID" />
                        <asp:BoundField DataField="TodoName" HeaderText="Todo Name" Visible="true" SortExpression="TodoName" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true" SortExpression="TodoNotes" />
                        <asp:TemplateField HeaderText="Completed" SortExpression="Completed">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkCompleted" runat="server" Checked='<%# Convert.ToBoolean(Eval("Completed")) %>'
                                    OnCheckedChanged="chkCompleted_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="~/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
    </div>
    </div>

</asp:Content>
