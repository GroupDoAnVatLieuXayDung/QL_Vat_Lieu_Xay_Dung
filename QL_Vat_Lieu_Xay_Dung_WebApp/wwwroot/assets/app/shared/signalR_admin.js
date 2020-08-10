var connection = new signalR.HubConnectionBuilder()
    .withUrl("/vlxd_Hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
connection.start().catch(err => console.error(err.toString()));

connection.on("ReceiveMessage", (message) => {
    var template = $("#announcement-template").html();
    var html = Mustache.render(template, {
        Content: message.content,
        Id: message.id,
        Title: message.title,
        Avatar: message.image,
        DateCreated: moment(message.DateCreated).fromNow()
    });
    if (parseInt($("#totalAnnouncement").text()) === 0) {
        html += $("#announcement-tag-template").html();
    }
    $("#announcementList").prepend(html);

    var totalAnnounce = parseInt($("#totalAnnouncement").text()) + 1;

    $("#totalAnnouncement").text(totalAnnounce);
});