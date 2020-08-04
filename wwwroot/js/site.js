// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function changeTheP() {
    let change = document.getElementById("changeThis");
    change.innerHTML = "<select asp-for=\"Sex\" asp-items=\"Model.SexItems\" />";
}
