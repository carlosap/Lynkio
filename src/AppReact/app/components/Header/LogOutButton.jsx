import React, { Component } from 'react'
var LogOutButton = (props) => {

    return (
        <div id="logout" className="btn-header transparent pull-right">
            <span> <a href="login.html" title="Sign Out" data-action="userLogout" data-logout-msg="You can improve your security further after logging out by closing this opened browser"><i className="fa fa-sign-out"></i></a> </span>
        </div>
    );
};
export default LogOutButton;