//$(function() { // USE WHEN YOU WANT TO LISTEN SINCE THE PAGE IS LOADED, comment button in html too

document.addEventListener("DOMContentLoaded", function () { // USE WHEN YOU ONLY WANT TO LISTEN SINCE BUTTON IS CLICKED
    var startRecognizeOnceAsyncButton = document.getElementById("startRecognizeOnceAsyncButton"); // USE WHEN YOU ONLY WANT TO LISTEN SINCE BUTTON IS CLICKED
    startRecognizeOnceAsyncButton.addEventListener("click", function () { // USE WHEN YOU ONLY WANT TO LISTEN SINCE BUTTON IS CLICKED

        var subscriptionKey = "000a6341694b42f5898d226f5e96c9ca";
        var serviceRegion = "westus";

        var speechConfig = SpeechSDK.SpeechConfig.fromSubscription(subscriptionKey, serviceRegion);

        speechConfig.speechRecognitionLanguage = "en-US";
        var audioConfig  = SpeechSDK.AudioConfig.fromDefaultMicrophoneInput();
        var recognizer = new SpeechSDK.SpeechRecognizer(speechConfig, audioConfig);

        recognizer.startContinuousRecognitionAsync();

        recognizer.recognized = function(s, e){
            var urlParams = new URLSearchParams(window.location.search);
            var sessionId = urlParams.get('sessionId');

            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", "/API/Voice?voice=" + e.result.text + "&sessionId=" + sessionId, false);
            xhttp.send();
            var result = xhttp.responseText;
            var array = result.split(',');
            if(array[0] === "redirect") {
                window.location.replace(array[1]);
            }
        };
    }); // USE WHEN YOU ONLY WANT TO LISTEN SINCE BUTTON IS CLICKED
}); // USE WHEN YOU ONLY WANT TO LISTEN SINCE BUTTON IS CLICKED
