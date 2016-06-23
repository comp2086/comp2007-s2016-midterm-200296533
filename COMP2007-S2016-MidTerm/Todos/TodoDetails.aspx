<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Todo Details</h2>
            </div>
            <div class="col-md-8 col-md-offset-2">
                <!-- Form -->
                <div class="form-group">
                    <label for="txtTodoName" class="control-label">Todo Name: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTodoName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodoName"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Team Name is Required</div>'
                                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtTodoNotes" class="control-label">Todo Description: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTodoNotes" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTodoNotes"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Team Description is Required</div>'
                                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtTodoNotes" class="control-label">Completed: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:CheckBox ID="chkCompleted" runat="server" /> Yes
                        </div>
                        <div class="col-md-5">
                        </div>
                    </div>
                </div>
                <div class="text-right">
                    <div class="row">
                        <div class="col-md-7">
                            <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-default" runat="server"
                                UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                            <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
