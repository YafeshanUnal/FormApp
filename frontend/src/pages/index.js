import { setIsLogin } from "@/redux/slice";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { useRouter } from "next/router";

export const Login = () => {
	const [username, setUsername] = useState("");
	const [password, setPassword] = useState("");
	const dispatch = useDispatch();
	const router = useRouter();
	const handleLogin = () => {
		const data = { username: username, password: password };

		fetch("http://localhost:5202/Login/login", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(data),
		}).then((response) => {
			if (response.status === 200) {
				dispatch(setIsLogin(true));
				router.push("/forms");
			} else {
				dispatch(setIsLogin(false));
			}
		});
	};

	return (
		<div className="d-flex align-items-center justify-content-center vh-100">
			<div className="d-flex flex-column align-items-center justify-content-center">
				<div className="input-group mb-3">
					<input
						type="text"
						className="form-control"
						placeholder="Username"
						aria-label="Username"
						aria-describedby="basic-addon2"
						onChange={(e) => setUsername(e.target.value)}
					/>
				</div>
				<div className="input-group mb-3">
					<input
						type="password"
						className="form-control"
						placeholder="Password"
						aria-label="Password"
						aria-describedby="basic-addon2"
						onChange={(e) => setPassword(e.target.value)}
					/>
				</div>
				<button className="btn btn-primary" onClick={handleLogin}>
					Login
				</button>
			</div>
		</div>
	);
};

export default Login;
