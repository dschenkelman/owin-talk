owin-talk
=========
Repository for the assets used during the Southworks brown bag OWIN talk. 
If you'd like to use any of the assets feel free to do it. If you get the chance, let me know so I know that this is being used.

##Setup
1. Install Katana, for example using Chocolatey `cinst OwinHost –pre`.
1. Open the **Owin.Sample.sln** solution using Visual Studio.
1. Configure the **Owin.Sample** project startup settings using:
	* Start external program: Path to OwinHost.exe (C:\Chocolatey\lib\OwinHost.1.1.0-beta2\tools\OwinHost.exe)
	* Parameters: `/p=8080 /v`
	* Working directory: Directory where Owin.Sample.csproj is located.
1. Open the deck and start the presentation.

##Deck
1. Start in first slide - OWIN

	> We are going to discuss what OWIN is (and what it is not). Explain the basic concepts that will usually come up when talking about OWIN and get familiar with what the AppFunc is.

2. Switch to second slide - What is it?

	> Explain that it is a spec. Browse [spec](http://owin.org/spec/owin-1.0.0.html).

	> OWIN itself is not an implementation, mention Katana.

3. Switch to thrid slide - Concepts

	> **Web application**: Your app.

	> **Middleware**: Any component that inspects, routes, or modifies request and/or response messages. This could involve components that implement Auth, IP filtering, and Web Frameworks should provide adapters in the form of middleware. Used to form a pipeline.

	> **Server**: Refers to server from a low level point of view. Component that creates the HTTP socket, listen for requests and send to OWIN pipeline.

	> **Process**: Mention that sometimes (IIS example, server and process are the same component).

4. Switch to thrid slide - AppFunc

	> Middleware components must provide an entry point that matches that signature.

	> The environment is a dictionary that must be compliant with the spec. Additional keys might be available and added.

	> Completion of the task indicates that the work is done.

##Demo
1. Open Visual Studio.

1. Expand references in **Owin.Sample** project.

	> Mention **Owin** and **Microsoft.Owin.Host.HttpListener** packages. The first one provides `IAppBuilder` useful to build the middleware pipeline, the latter is a server implementation. Both are part of Katana, MS's implementation of OWIN.

1. Open **IpFilterMiddleware.cs**.

1. Walk through the code.

	> Mention **AppFunc** using statement.

	> Talk about first constructor parameter being the next component in the pipeline.		

	> Talk about convention approach in Katana. **Invoke** method for AppFunc.
	
1. Open **Startup.cs**.

	> Bring up another convention point, **Startup** class name and **Configuration** method name.

1. Walk through **Configuration** method.
1. F12 in **UseIpFiltering** method.

	> Open [link](http://www.asp.net/web-api/overview/hosting-aspnet-web-api/host-aspnet-web-api-in-an-azure-worker-role) and show **Configure Web API for Self-Host** as an example of Framework with OWIN adapter.

1. F5 in Visual Studio. Browse to localhost:8080.
	
##Resources
* http://weblogs.asp.net/pglavich/archive/2013/04/05/owin-katana-and-getting-started.aspx
* http://www.asp.net/aspnet/overview/owin-and-katana/an-overview-of-project-katana
* http://owin.org/spec/owin-1.0.0.html
* http://www.asp.net/web-api/overview/hosting-aspnet-web-api/host-aspnet-web-api-in-an-azure-worker-role