<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="TeacherSubject.aspx.cs" Inherits="SchoolManagementSystem.Admin.TeacherSubject" %>
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
                        ErrorMessage="Subject is required" ForeColor="Red" ControlTovalidate="ddlSubject" Display="Dynamic" 
                        SetFocusOnError="true"  InitialValue="Select Subject"></asp:RequiredFieldValidator>
                </div>
            </div>


             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
               <div class="col-md-6">
                    <label for="ddlTeacher">Teacher</label>
                    <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Teacher is required" ForeColor="Red" ControlTovalidate="ddlTeacher" Display="Dynamic" 
                        SetFocusOnError="true"  InitialValue="Select Teacher"></asp:RequiredFieldValidator>
                </div>
            </div>

             

            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Assign Teacher" OnClick="btnAdd_Click"/>
                     
                </div>
            </div>

            
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!"
                        AllowPaging="True" PageSize="4" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Name">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="className" HeaderText="Class">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="subjectName" HeaderText="Subject">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
             <HeaderStyle BackColor="#5558C9" ForeColor="White" />
        </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
