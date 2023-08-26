// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const buttonRight = document.getElementById('rightarrow');
const buttonLeft = document.getElementById('leftarrow');

buttonRight.onclick = function () {
    document.getElementById('horizontalscroll').scrollLeft += 1000

};
buttonLeft.onclick = function () {
    document.getElementById('horizontalscroll').scrollLeft -= 1000

};
