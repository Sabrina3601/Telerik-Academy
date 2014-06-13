console.log('Live DIVs:');
getLiveDivs();
console.log('Static DIVs:');
getStaticDivs();

function getLiveDivs() {
    var wrapperDivLive = document.getElementsByTagName('div');
    var innerDivLive = [];

    for (var i = 0, length = wrapperDivLive.length; i < length; i++) {
        innerDivLive.push(wrapperDivLive[i].getElementsByTagName('div'));
    }

    for (var j = 0, length = innerDivLive.length; j < length; j++) {
        console.log(innerDivLive[j]);
    }
}

function getStaticDivs() {
    var divStatic = document.querySelectorAll('div > div');
    for (var i = 0, length = divStatic.length; i < length; i++) {
        console.log(divStatic);
    }
}