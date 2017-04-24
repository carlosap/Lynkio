import React, { Component } from 'react'
var SearchBox = (props) => {

    return (

            <form action="search.html" className="header-search pull-right">
                <input id="search-fld" type="text" name="param" placeholder="Find reports and more" data-autocomplete='["ActionScript","AppleScript"]' />
                <button type="submit">
                    <i className="fa fa-search"></i>
                </button>
                <a href="javascript:void(0);" id="cancel-search-js" title="Cancel Search"><i className="fa fa-times"></i></a>
            </form>

    );
};
export default SearchBox;