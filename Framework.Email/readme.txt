The email service uses config to determine the SMTP host, port, credentials and delivery method.  To send emails over the
network add the following to your config file:

	<system.net>
		<mailSettings>
			<smtp deliveryMethod="network">
				<network
				  host="Mail.lowell2.local"
				  port="25"
				  defaultCredentials="false"
				/>
			</smtp>
		</mailSettings>
	</system.net>


This is preferable over passing the params to SmtpClient constructor because we can avoid sending emails in integration tests
and drop them in a folder.  To accommplish this add the following to the integration tests config file:

	<system.net>
		<mailSettings>
			<smtp deliveryMethod="SpecifiedPickupDirectory">
				<specifiedPickupDirectory pickupDirectoryLocation="c:\TestEmailDropFolder" />
			</smtp>
		</mailSettings>
	</system.net>