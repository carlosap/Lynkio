import React, {Component} from 'react'
var Nav = (props) => {

    return(
			<nav>
				<ul>
					<li className="active">
						<a href="#" title="Dashboard"><i className="fa fa-lg fa-fw fa-home"></i> <span className="menu-item-parent">Dashboard</span></a>
					</li>

					<li>
						<a href="inbox.html"><i className="fa fa-lg fa-fw fa-inbox"></i> <span className="menu-item-parent">Todo</span> <span className="badge pull-right inbox-badge margin-right-13">14</span></a>
					</li>

					<li>
						<a href="#"><i className="fa fa-lg fa-fw fa-bar-chart-o"></i> <span className="menu-item-parent">Chart</span></a>
					</li>
				</ul>
			</nav>			
    );
};
export default Nav;