// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getCount() {
    $.getJSON("tools/getcount", { format: "json" }).done(function (data) {
        return data.count;
    })
}