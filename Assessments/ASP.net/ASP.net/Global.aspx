<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        Application["TotalUsers"] = 0;
        Application["ActiveUsers"] = 0;
    }

    void Session_Start(object sender, EventArgs e)
    {
        Application["TotalUsers"] =
            (int)Application["TotalUsers"] + 1;

        Application["ActiveUsers"] =
            (int)Application["ActiveUsers"] + 1;
    }

    void Session_End(object sender, EventArgs e)
    {
        Application["ActiveUsers"] =
            (int)Application["ActiveUsers"] - 1;
    }

</script>