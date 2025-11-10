<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolManagementSystem.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Innovate Charter School - Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
            overflow-x: hidden;
        }

        .login-container {
            min-height: 100vh;
            display: flex;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            position: relative;
        }

        .login-container::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: url('data:image/svg+xml,<svg width="100" height="100" xmlns="http://www.w3.org/2000/svg"><defs><pattern id="grid" width="100" height="100" patternUnits="userSpaceOnUse"><path d="M 100 0 L 0 0 0 100" fill="none" stroke="rgba(255,255,255,0.03)" stroke-width="1"/></pattern></defs><rect width="100%" height="100%" fill="url(%23grid)"/></svg>');
            opacity: 0.5;
        }

        .image-section {
            flex: 1;
            background: linear-gradient(rgba(102, 126, 234, 0.3), rgba(118, 75, 162, 0.3)), 
                        url('../Image/login2.jpg');
            background-size: cover;
            background-position: center;
            display: flex;
            align-items: center;
            justify-content: center;
            position: relative;
            overflow: hidden;
        }

        .image-section::after {
            content: '';
            position: absolute;
            top: -50%;
            right: -50%;
            width: 200%;
            height: 200%;
            background: radial-gradient(circle, rgba(255,255,255,0.1) 0%, transparent 70%);
            animation: float 20s infinite ease-in-out;
        }

        @keyframes float {
            0%, 100% { transform: translate(0, 0) rotate(0deg); }
            50% { transform: translate(-20px, 20px) rotate(5deg); }
        }

        .school-branding {
            z-index: 2;
            text-align: center;
            color: white;
            padding: 40px;
        }

        .school-logo {
            width: 120px;
            height: 120px;
            background: white;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0 auto 30px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            font-size: 48px;
            font-weight: bold;
            color: #667eea;
        }

        .school-name {
            font-size: 42px;
            font-weight: 700;
            margin-bottom: 15px;
            text-shadow: 0 4px 20px rgba(0,0,0,0.3);
            letter-spacing: -0.5px;
        }

        .school-tagline {
            font-size: 18px;
            opacity: 0.95;
            font-weight: 300;
            letter-spacing: 0.5px;
        }

        .form-section {
            flex: 1;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 40px;
            background: white;
            position: relative;
            z-index: 1;
        }

        .login-card {
            width: 100%;
            max-width: 480px;
            padding: 50px 40px;
        }

        .login-header {
            margin-bottom: 40px;
        }

        .login-title {
            font-size: 32px;
            font-weight: 700;
            color: #1a202c;
            margin-bottom: 10px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
        }

        .login-subtitle {
            color: #718096;
            font-size: 15px;
            font-weight: 400;
        }

        .form-group {
            margin-bottom: 25px;
            position: relative;
        }

        .form-label {
            display: block;
            font-size: 14px;
            font-weight: 600;
            color: #4a5568;
            margin-bottom: 8px;
        }

        .form-control {
            width: 100%;
            padding: 14px 20px;
            border: 2px solid #e2e8f0;
            border-radius: 12px;
            font-size: 15px;
            transition: all 0.3s ease;
            background: #f7fafc;
        }

        .form-control:focus {
            outline: none;
            border-color: #667eea;
            background: white;
            box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.1);
        }

        .btn-login {
            width: 100%;
            padding: 16px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            border: none;
            border-radius: 12px;
            font-size: 16px;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s ease;
            margin-top: 10px;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            box-shadow: 0 4px 15px rgba(102, 126, 234, 0.4);
        }

        .btn-login:hover {
            transform: translateY(-2px);
            box-shadow: 0 6px 25px rgba(102, 126, 234, 0.5);
        }

        .btn-login:active {
            transform: translateY(0);
        }

        .message-area {
            margin-top: 20px;
            text-align: center;
        }

        .feature-badges {
            display: flex;
            gap: 15px;
            margin-top: 30px;
            padding-top: 30px;
            border-top: 1px solid #e2e8f0;
        }

        .badge {
            flex: 1;
            text-align: center;
            padding: 15px;
            background: #f7fafc;
            border-radius: 10px;
        }

        .badge-icon {
            font-size: 24px;
            margin-bottom: 5px;
        }

        .badge-text {
            font-size: 12px;
            color: #718096;
            font-weight: 500;
        }

        @media (max-width: 768px) {
            .login-container {
                flex-direction: column;
            }

            .image-section {
                min-height: 250px;
            }

            .school-name {
                font-size: 28px;
            }

            .school-logo {
                width: 80px;
                height: 80px;
                font-size: 32px;
            }

            .login-card {
                padding: 30px 20px;
            }

            .feature-badges {
                flex-direction: column;
            }
        }

        .floating-shapes {
            position: absolute;
            width: 100%;
            height: 100%;
            overflow: hidden;
            z-index: 1;
        }

        .shape {
            position: absolute;
            opacity: 0.1;
            animation: float-shape 20s infinite ease-in-out;
        }

        .shape:nth-child(1) {
            width: 80px;
            height: 80px;
            background: white;
            border-radius: 50%;
            top: 20%;
            left: 20%;
            animation-delay: 0s;
        }

        .shape:nth-child(2) {
            width: 120px;
            height: 120px;
            background: white;
            border-radius: 20px;
            top: 60%;
            left: 70%;
            animation-delay: 3s;
        }

        .shape:nth-child(3) {
            width: 60px;
            height: 60px;
            background: white;
            border-radius: 50%;
            top: 80%;
            left: 30%;
            animation-delay: 6s;
        }

        @keyframes float-shape {
            0%, 100% { transform: translateY(0) rotate(0deg); }
            50% { transform: translateY(-30px) rotate(180deg); }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="image-section">
                <div class="floating-shapes">
                    <div class="shape"></div>
                    <div class="shape"></div>
                    <div class="shape"></div>
                </div>
                <div class="school-branding">
                    <div class="school-logo">ICS</div>
                    <h1 class="school-name">Innovate Charter School</h1>
                    <p class="school-tagline">Empowering Tomorrow's Leaders Today</p>
                </div>
            </div>

            <div class="form-section">
                <div class="login-card">
                    <div class="login-header">
                        <h2 class="login-title">Welcome Back</h2>
                        <p class="login-subtitle">Sign in to access your dashboard</p>
                    </div>

                    <div class="form-group">
                        <label class="form-label" for="inputEmail">Email Address</label>
                        <input 
                            id="inputEmail" 
                            type="text" 
                            placeholder="Enter your email" 
                            required="" 
                            runat="server" 
                            autofocus="" 
                            class="form-control" 
                        />
                    </div>

                    <div class="form-group">
                        <label class="form-label" for="inputPassword">Password</label>
                        <input 
                            id="inputPassword" 
                            type="password" 
                            placeholder="Enter your password" 
                            required="" 
                            runat="server" 
                            class="form-control" 
                        />
                    </div>

                    <asp:Button 
                        ID="btnLogin" 
                        runat="server" 
                        Text="Sign In" 
                        CssClass="btn-login"
                        BackColor="#667eea"
                        OnClick="btnLogin_Click"
                    />

                    <div class="message-area">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>

                    <div class="feature-badges">
                        <div class="badge">
                            <div class="badge-icon">🔒</div>
                            <div class="badge-text">Secure Access</div>
                        </div>
                        <div class="badge">
                            <div class="badge-icon">⚡</div>
                            <div class="badge-text">Fast Login</div>
                        </div>
                        <div class="badge">
                            <div class="badge-icon">📱</div>
                            <div class="badge-text">Mobile Ready</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>