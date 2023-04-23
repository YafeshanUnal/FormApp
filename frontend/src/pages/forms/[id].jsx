import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const DetailPage = () => {
	const [data, setData] = useState([]);
	const { id } = useParams();
	console.log("iads", id);

	useEffect(() => {
		fetch(`http://localhost:5202/api/Form/GetById/${id}`)
			.then((response) => response.json().then((data) => setData(data.value)))
			.then((data) => console.log(data));
	}, [id]);
	const { register, handleSubmit, setValue } = useForm({
		// defaultValues: { name: data.name, description: data.description },
	});

	const onSubmit = (data) => {
		console.log(data);
	};

	return (
		<div className="d-flex justify-content-center align-items-center vh-100">
			<form className="border p-3 rounded" onSubmit={handleSubmit(onSubmit)}>
				<div className="mb-3">
					<label htmlFor="name" className="form-label">
						Name
					</label>
					<input
						type="text"
						className="form-control"
						id="name"
						{...register("name")}
					/>
				</div>
				<div className="mb-3">
					<label htmlFor="age" className="form-label">
						Age
					</label>
					<input
						type="text"
						className="form-control"
						id="age"
						{...register("age")}
					/>
				</div>
				<button type="submit" className="btn btn-primary">
					Submit
				</button>
			</form>
		</div>
	);
};

export default DetailPage;
