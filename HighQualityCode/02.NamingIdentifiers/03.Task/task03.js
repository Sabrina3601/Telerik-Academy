function ButtonClick(event, arg) {
    var myWindow = window;
    var browser = myWindow.navigator.appCodeName;
    var ism = browser == "Mozilla";
    if (ism) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
