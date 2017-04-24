import React, { Component } from 'react'
var RefreshButton = (props) => {

    return (
        <span className="ribbon-button-alignment">
            <span id="refresh" className="btn btn-ribbon" 
            data-action="resetWidgets" 
            data-title="refresh" 
            rel="tooltip" 
            data-placement="bottom" 
            data-original-title="<i className='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." 
            data-html="true">
                <i className="fa fa-refresh"></i>
            </span>
        </span>
    );
};
export default RefreshButton;