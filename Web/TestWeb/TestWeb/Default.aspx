<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TestWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Test form</h2>
	<form action="Default.aspx">
		<table>
			<tr>
				<td><label for="name">Your name:</label></td>
				<td><input type="text" id="name" /></td>
			</tr>
			<tr>
				<td><label for="color">Your favourite color:</label></td>
				<td>
					<select id="color">
						<option>Green</option>
						<option>Red</option>
						<option>Yellow</option>
					</select>
				</td>
			</tr>
			<tr>
				<td><label for="18-years">You are older than 18 years</label></td>
				<td><input type="checkbox" id="18-years" /></td>
			</tr>
			<tr>
				<td>Your favourite time of day:</td>
				<td>
					<input type="radio" id="radio-morning" /><label for="radio-morning">Morning</label><br />
					<input type="radio" id="radio-evening" /><label for="radio-evening">Evening</label><br />
					<input type="radio" id="radio-night" /><label for="radio-night">Night</label><br />
				</td>
			</tr>
			<tr>
				<td colspan="2"><input type="submit" /></td>
			</tr>
		</table>
		
	</form>
</asp:Content>
