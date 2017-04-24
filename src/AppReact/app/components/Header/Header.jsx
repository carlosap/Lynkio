import React, {Component} from 'react'
import LogoGroup from 'LogoGroup'
import ProjectsDropDown from 'ProjectsDropDown'
import PullRightNav from 'PullRightNav'
var Header = (props) =>{
    return(

		<header id="header">
            <LogoGroup/>
            <ProjectsDropDown/>
            <PullRightNav/>
		</header>

    );
};
export default Header;