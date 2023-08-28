<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Marks.aspx.cs" Inherits="SchoolManagementSystem.Admin.Marks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image:url('../Image/bg.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed;">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center "> <b>Add Marks</b></h3>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="ddlClass">Class</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Class is required" ForeColor="Red" ControlTovalidate="ddlClass" Display="Dynamic" 
                        SetFocusOnError="true" InitialValue="Select Class"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6">
                    <label for="ddlSubject">Subject</label>
                    <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="Subject is required" ForeColor="Red" ControlTovalidate="ddlClass" Display="Dynamic" 
                        SetFocusOnError="true"  InitialValue="Select Subject"></asp:RequiredFieldValidator>
                </div>
            </div>


             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-12">
                    <label for="txtRoll">Roll Number</label>
                    <asp:TextBox ID="txtRoll" runat="server" CssClass="form-control" placeholder="Enter Roll No." TextMode="Number"  required></asp:TextBox>
                </div>
            </div>


             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtTotal">Obtain Marks(Student's marks)</label>
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" placeholder="Enter Obtain Marks" TextMode="Number"  required></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="txtOut">Out Of Marks</label>
                    <asp:TextBox ID="txtOut" runat="server" CssClass="form-control" placeholder="Enter Out of Marks" TextMode="Number"  required></asp:TextBox>
                </div>
            </div>

            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Marks" OnClick="btnAdd_Click"/>
                     
                </div>
            </div>

            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" AllowPaging="True" PageSize="4"
                        DataKeyNames="examId">
                         <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
