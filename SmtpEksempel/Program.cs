using MailKit;
using MailKit.Net;
using MailKit.Net.Smtp;
using MimeKit;

SmtpClient client = new SmtpClient();

Console.WriteLine("Connecting to Server...");

client.Connect("localhost",25, false);

var message = new MimeMessage();

message.Subject = "Test";

message.From.Add(new MailboxAddress("Jakob spiel","jsk@eucsyd.dk"));

message.To.Add(new MailboxAddress("Someone","someone@nothing.com"));

message.Body = new TextPart("html", """
        <h1>Hello. World<h1/> 

        <h2>😆😆😆😆😆😆<h2/>

        <table style="width:800px">
          <tr>
            <th>Company</th>
            <th>Contact</th>
            <th>Country</th>
          </tr>
          <tr>
            <td>Alfreds Futterkiste</td>
            <td>Maria Anders</td>
            <td>Germany</td>
          </tr>
          <tr>
            <td>Centro comercial Moctezuma</td>
            <td>Francisco Chang</td>
            <td>Mexico</td>
          </tr>
        </table>
    """);

Console.WriteLine("Sending message...");
client.Send(message);
Console.WriteLine("Message Sent...");

Console.WriteLine("Disconnecting...");
client.Disconnect(false);
