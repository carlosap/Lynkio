import React, { Component } from 'react'
import RefreshButton from 'RefreshButton'
import BreadCrumb from 'BreadCrumb'
var Ribbon = (props) => {

    return (
        <div id="ribbon">
            <RefreshButton/>
            <BreadCrumb/>
        </div>
    );
};
export default Ribbon;