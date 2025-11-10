<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/TeacherMst.Master" AutoEventWireup="true" CodeBehind="MarksDetails.aspx.cs" Inherits="SchoolManagementSystem.Teacher.MarksDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image:url('../Image/bg.jpg'); width:100%; height:100%; background-repeat:no-repeat; background-size:cover; background-attachment:fixed;">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center "><b>Mark Details</b> </h3>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">

                <div class="col-md-6">
                    <label for="ddlClass">Class</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Class is required" 
                        ControlToValidate="ddlClass" Display="Dynamic" ForeColor="Red" InitialValue="Select class" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6">
                    <label for="txtRoll">Student's Roll Number</label>
                    <asp:TextBox ID="txtRoll" runat="server" CssClass="form-control" placeholder="Enter Roll Number" TextMode="Number" required></asp:TextBox>
                </div>
            </div>


            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Get Marks" OnClick="btnAdd_Click"/>
                     
                </div>
            </div>

            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" 
                        AllowPaging="True" PageSize="4" DataKeyNames="classId">
                         <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
