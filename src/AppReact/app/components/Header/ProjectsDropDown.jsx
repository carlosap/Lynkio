import React, {Component} from 'react'
var ProjectsDropDown = (props) => {

    return(
			<div className="project-context hidden-xs">
				<span className="label">Projects:</span>
				<span className="project-selector dropdown-toggle" data-toggle="dropdown">Recent projects <i className="fa fa-angle-down"></i></span>
				<ul className="dropdown-menu">
					<li>
						<a href="javascript:void(0);">Online e-merchant management system - attaching integration with the iOS</a>
					</li>
					<li>
						<a href="javascript:void(0);">Notes on pipeline upgradee</a>
					</li>
					<li>
						<a href="javascript:void(0);">Assesment Report for merchant account</a>
					</li>
					<li className="divider"></li>
					<li>
						<a href="javascript:void(0);"><i className="fa fa-power-off"></i> Clear</a>
					</li>
				</ul>
			</div>
    );
};
export default ProjectsDropDown;