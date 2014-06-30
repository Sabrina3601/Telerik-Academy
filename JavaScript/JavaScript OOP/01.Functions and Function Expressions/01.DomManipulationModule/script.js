var domModule = (function () {
    function appendElement(element, parentSelector) {
        var parent = document.querySelectorAll(parentSelector);
        for (var i = 0; i < parent.length; i++) {
            parent[i].appendChild(element.cloneNode(true));
        }
    }

    function removeElement(selector) {
        var element = document.querySelectorAll(selector);
        if (element.length <= 0) {
            console.log('No more divs for remove');
        }
        else {
            element[element.length - 1].parentElement.removeChild(element[element.length - 1]);
        }
       
    }

    function addEvent(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector);
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventType, eventHandler);
        }

    }

    var elementsBuffer = [];
    var MAX_BUFFER_SIZE = 10;
    function appendToBuffer(element, parentSelector) {
        elementsBuffer.push(element);
        var parent = document.querySelector(parentSelector);

        if (elementsBuffer.length === MAX_BUFFER_SIZE) {
            var fragment = document.createDocumentFragment();
            for (var i = 0; i < MAX_BUFFER_SIZE; i++) {
                fragment.appendChild(elementsBuffer[i]);
            }
            parent.appendChild(fragment);
            elementsBuffer = [];
        }
    }


    return {
        appendElement: appendElement,
        removeElement: removeElement,
        addEvent: addEvent,
        appendToBuffer: appendToBuffer
    }
}());