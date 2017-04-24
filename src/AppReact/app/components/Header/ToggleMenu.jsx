import React, { Component } from 'react'
var ToggleMenu = (props) => {

    return (
        <div id="hide-menu" className="btn-header pull-right">
            <span> <a href="javascript:void(0);" data-action="toggleMenu" title="Collapse Menu"><i className="fa fa-reorder"></i></a> </span>
        </div>
    );
};
export default ToggleMenu;