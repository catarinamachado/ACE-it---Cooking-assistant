//$(function() { // USE WHEN YOU WANT TO LISTEN SINCE THE PAGE IS LOADED, comment button in html too

document.addEventListener("DOMContentLoaded", function () { // USE WHEN YOU ONLY WANT TO LISTEN SINCE BUTTON IS CLICKED

    var startRecognizeOnceAsyncButton = document.getElementById("startRecognizeOnceAsyncButton");
    var subscriptionKey = "000a6341694b42f5898d226f5e96c9ca";
    var serviceRegion = "westus";

    startRecognizeOnceAsyncButton.addEventListener("click", function () {
        startRecognizeOnceAsyncButton.disabled = true;
        var speechConfig = SpeechSDK.SpeechConfig.fromSubscription(subscriptionKey, serviceRegion);

        speechConfig.speechRecognitionLanguage = "en-US";
        var audioConfig  = SpeechSDK.AudioConfig.fromDefaultMicrophoneInput();
        var recognizer = new SpeechSDK.SpeechRecognizer(speechConfig, audioConfig);

        recognizer.startContinuousRecognitionAsync();

        recognizer.recognized = function(s, e){
            console.log(e.result.text);
        };
    });
});
