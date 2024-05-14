{
    "Logging": {
		"LogLevel": {
			"Default": "None",
			"Microsoft.*": "None",
			"Microsoft.EntityFrameworkCore.Database.Command": "None",
			"Microsoft.Hosting.Lifetime": "Information"
		}
	},
	"AllowedHosts": "*",
	"AspNetCoreIdentity": {
		"Password": {
			"RequireDigit": true,
			"RequireLowercase": false,
			"RequireNonAlphanumeric": false,
			"RequireUppercase": true,
			"RequiredLength": 4,
			"RequiredUniqueChars": 0
		},
		"Lockout": {
			"DefaultLockoutTimeSpanInSecond": 15,
			"MaxFailedAccessAttempts": 3,
			"AllowedForNewUsers": true
		},
		"User": {
			"AllowedUserNameCharacters": "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+",
			"RequireUniqueEmail": false
		},
		"SignIn": {
			"RequireConfirmedEmail": true,
			"RequireConfirmedPhoneNumber": false
		}
	},
	"Database": {
		"FuDever": {
			"ConnectionString": "",
			"CommandTimeOut": 10,
			"EnableRetryOnFailure": 3,
			"EnableSensitiveDataLogging": true,
			"EnableDetailedErrors": true,
			"EnableThreadSafetyChecks": true,
			"EnableServiceProviderCaching": true
		}
	},
	"Authentication": {
		"Common": {
			"DefaultAuthenticateScheme": "Bearer",
			"DefaultScheme": "Bearer",
			"DefaultChallengeScheme": "Bearer"
		},
		"Type": {
			"Jwt": {
				"ValidateIssuer": true,
				"ValidateAudience": true,
				"ValidateLifetime": true,
				"ValidateIssuerSigningKey": true,
				"RequireExpirationTime": true,
				"ValidIssuer": "",
				"ValidAudience": "",
				"IssuerSigningKey": "rVudd4lonZppJDzMhdXL3OtbendsNXsjwhd248WWsL",
				"ValidTypes": [
					"JWT"
				]
			}
		}
	},
	"MailSending": {
		"GoogleGmail": {
			"Mail": "",
			"DisplayName": "Fu Dever",
			"Password": "",
			"Host": "smtp.gmail.com",
			"Port": 587,
			"WebUrl": ""
		}
	},
	"SmtpServerCommunication": {
		"GoogleGmail": {
			"Sender": "",
			"Host": "smtp.gmail.com",
			"Port": 587
		}
	},
	"Swagger": {
		"Swashbuckle": {
			"Doc": {
				"Name": "v1",
				"Info": {
					"Version": "v1",
					"Title": "Fu Dever Web Api",
					"Description": "An ASP.NET Core Web Api for FuDever.com website",
					"Contact": {
						"Name": "Fu Dever Help Desk",
						"Email": ""
					},
					"License": {
						"Name": "MIT",
						"Url": "https://opensource.org/license/mit/"
					}
				}
			},
			"Security": {
				"Definition": {
					"Name": "Bearer",
					"SecurityScheme": {
						"Description": "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
						"Name": "Authorization",
						"In": 1,
						"Type": 0,
						"Scheme": "Bearer"
					}
				},
				"Requirement": {
					"OpenApiSecurityScheme": {
						"Reference": {
							"Type": 6,
							"Id": "Bearer"
						},
						"Scheme": "OAuth2",
						"Name": "Bearer",
						"In": 1
					},
					"Values": []
				}
			}
		}
	},
	"CloudStorage": {
		"GoogleDrive": {
			"type": "",
			"project_id": "",
			"private_key_id": "",
			"private_key": "",
			"client_email": "",
			"client_id": "",
			"auth_uri": "https://accounts.google.com/o/oauth2/auth",
			"token_uri": "https://oauth2.googleapis.com/token",
			"auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
			"client_x509_cert_url": "",
			"universe_domain": "googleapis.com"
		},
		"GoogleDriveFolder": {
			"ParentFolderId": ""
		}
	},
	"OAuth": {
		"Google": {
			"client_id": "",
			"project_id": "",
			"auth_uri": "https://accounts.google.com/o/oauth2/auth",
			"token_uri": "https://oauth2.googleapis.com/token",
			"auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
			"client_secret": "",
			"redirect_uris": [
				""
			]
		}
	},
	"AdminConfirmedKey": "17#jY!@P$b",
	"ApiController": {
		"SuppressAsyncSuffixInActionNames": false
	},
	"ApiRateLimiter": {
		"FixedWindow": {
			"RemoteIpAddress": {
				"PermitLimit": 6,
				"QueueProcessingOrder": 0,
				"QueueLimit": 0,
				"Window": 10,
				"AutoReplenishment": false
			}
		}
	},
	"Cache": {
		"Redis": {
			"ConnectionString": ""
		}
	},
	"DataProtection": {
		"Key": "wJjSYBNyLTP8l9nVjjRn"
	}
}