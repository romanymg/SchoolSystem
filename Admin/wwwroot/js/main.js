function SaveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function HideNavGroup() {
    document.querySelectorAll(".mud-nav-group").forEach(function (group) {
        if (group.querySelectorAll("a").length === 0) {
            group.classList.add("hidden");
        }
    });
}