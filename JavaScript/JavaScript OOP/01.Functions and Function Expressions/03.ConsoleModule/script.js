var specialConsole = (function () {

    function formatString(args) {
        var text = args[0];
        if (args.length > 1) {     
            for (i = 0; i < args.length-1; i++) {
                 text =  text.replace('{' + (i) + '}', args[i + 1]);
            }
        }
         return text;
    }

    function writeLine() {
        console.log(formatString(arguments));
    }

    function writeError() {
        console.error(formatString(arguments));
    }

    function writeWarn() {
        console.warn(formatString(arguments));
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarn: writeWarn
    }
})();