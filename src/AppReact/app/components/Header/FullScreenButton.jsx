import React, { Component } from 'react'
var FullScreenButton = (props) => {

    return (


        <div id="fullscreen" className="btn-header transparent pull-right">
            <span> <a href="javascript:void(0);" data-action="launchFullscreen" title="Full Screen"><i className="fa fa-arrows-alt"></i></a> </span>
        </div>

    );
};
export default FullScreenButton;