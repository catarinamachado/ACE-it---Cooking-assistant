$(function() {
    var $_modal       = $('#help');
    var body          = $_modal.find("#body");
    var $_instruction = $(".instruction");
    var $_html        = $("<p>" + $_instruction[0].innerHTML + "</p>");
    var spans         = $_html.find("span");
    var map           = new Map();

    $_instruction.find("span").each(function () {
        var $_this = $(this);
        map.set($_this[0].innerText.toLowerCase(), $_this);
        $_this.click(function () {
            buildModal($_this, body, $_modal);
        })
    });

    $_modal.on('hidden.bs.modal', function () {
        body.empty();
    });

    spans.each(function () {
        var $_videos = $("#videos");
        var $_video = $(this).data("video");
        if ($_video == null) return;
        var url = $_video.replace("watch?v=", "v/");
        $_videos.append(
            "<div class='col'><div class='video-container'>" +
            "<iframe width='853' height='480' allowfullscreen='true' src='" + url + "'></iframe>" +
            "</div></div>"
        );
    });

    listen(map, body, $_modal, $_instruction);
});

function buildModal($_this, body, $_modal) {
    var options = new Map();

    body.append("<div class='py-3'><h2 style='text-align: center'>" + $_this.text() + "</h2></div>");
    body.append("<div>");
    $.each($_this.data(), function(k,v) {
        options.set(k,v);
        if(k === "video") {
            body.append("<p class='pb-2'><b>" + k + "</b>: " + "<a href='" + v + "'>" + v + "</a>" + "</p>");
        } else {
            body.append("<p class='pb-2'><b>" +k + "</b>: " + v + "</p>");
        }
    });
    body.append("</div>");
    $_modal.modal('show');

    return options;
}

function listen(map, body, $_modal, $_instruction) {
    var subscriptionKey = "000a6341694b42f5898d226f5e96c9ca";
    var serviceRegion = "westus";

    var speechConfig = SpeechSDK.SpeechConfig.fromSubscription(subscriptionKey, serviceRegion);

    speechConfig.speechRecognitionLanguage = "en-US";
    var audioConfig = SpeechSDK.AudioConfig.fromDefaultMicrophoneInput();
    var recognizer = new SpeechSDK.SpeechRecognizer(speechConfig, audioConfig);

    var options = null;
    recognizer.startContinuousRecognitionAsync();
    recognizer.recognized = function (s, e) {
        var string = e.result.text.toLowerCase().replace("?", "").replace(".", "");
        console.log(string);
        if(options == null) {
            if(string === "read") {
                var m = new SpeechSynthesisUtterance($_instruction[0].innerText);
                m.volume = 1;
                window.speechSynthesis.speak(m);
            }
            else if(map.has(string)) {
                options = buildModal(map.get(string), body, $_modal);
            } else if (string.length > 0) {
                sendToApi(string);
            }
        } else {
            if(string === "close") {
                options = null;
                $_modal.modal('hide');
            } else if(options.has(string)) {
                var value = options.get(string);
                if(string.includes("video")) {
                    window.location.replace(value);
                } else if (value.includes("href")) {
                    var href = value.match(/href="([^"]*)/)[1];
                    window.location.replace(href);
                } else {
                    var msg = new SpeechSynthesisUtterance(value);
                    msg.volume = 1;
                    window.speechSynthesis.speak(msg);
                }
            }
        }
    }
}

function sendToApi(string) {
    var urlParams = new URLSearchParams(window.location.search);
    var sessionId = urlParams.get('sessionId');

    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/API/Voice?voice=" + string +
        "&sessionId=" + sessionId +
        "&viewIndex=" + ($("#step")[0].innerText - 1),
        false);
    xhttp.send();
    var result = xhttp.responseText;
    var array = result.split(',');
    if (array[0] === "redirect") {
        window.location.replace(array[1]);
    }
}
