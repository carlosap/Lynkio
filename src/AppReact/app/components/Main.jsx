import React, { Component } from 'react';
import Header from 'Header'
import LeftPanel from 'LeftPanel'
import Ribbon from 'Ribbon'
var Main = (props) => {
    return (
        <div>
            <Header/>
            <LeftPanel/>
            <Ribbon/>
            <div id="main" role="main">
                <div id="content">
                    {props.children}
                </div>
            </div>
        </div>
    );
};
export default Main;