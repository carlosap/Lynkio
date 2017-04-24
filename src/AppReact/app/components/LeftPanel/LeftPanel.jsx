import React, {Component} from 'react'
import UserInfo from 'UserInfo'
import Nav from 'Nav'

var LeftPanel = (props) => {

    return(
		<aside id="left-panel">
            <UserInfo/>
            <Nav/>
			<span className="minifyme" data-action="minifyMenu"> 
				<i className="fa fa-arrow-circle-left hit"></i> 
			</span>
		</aside>
    );
};
export default LeftPanel;