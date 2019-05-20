$(function() {
    var $_modal       = $('#help');
    var body          = $_modal.find("#body");
    var $_instruction = $(".instruction");
    var $_html        = $("<p>" + $_instruction[0].innerHTML + "</p>");
    var spans         = $_html.find("span");

    $("span").each(function () {
       ($(this)).click(function () {
           var $_this = $(this);
           body.append("<div class='py-3'><h2 style='text-align: center'>" + $_this.text() + "</h2></div>");
           body.append("<div>");
           $.each($_this.data(), function(k,v) {
               if(k === "video") {
                   body.append("<p class='pb-2'><b>" + k + "</b>: " + "<a href='" + v + "'>" + v + "</a>" + "</p>");
               } else {
                   body.append("<p class='pb-2'><b>" +k + "</b>: " + v + "</p>");
               }
           });
           body.append("</div>");
           $_modal.modal('show');
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
});
