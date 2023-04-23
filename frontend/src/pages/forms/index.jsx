import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { setIsLogin } from "@/redux/slice";
import { useSelector } from "react-redux";
import { useRouter } from "next/router";
import Link from "next/link";
import DetailPage from "./[id]";
export const Homepage = () => {
	// bu sayfada http://localhost:5202/api/Form/GetAll bu adresteki formlar çekilecek ve burada tablo şeklinde gösterilecek
	// tablo şeklinde gösterilirken de her bir formun üzerine tıklandığında o formun detay sayfasına gidilecek
	const [forms, setForms] = useState([]);
	const [showPopup, setShowPopup] = useState(false);
	const { isLogin } = useSelector((state) => state.user);
	const [requestModel, setRequestModel] = useState({
		name: "",
		description: "",
		fields: "",
	});
	useEffect(() => {
		fetch("http://localhost:5202/api/Form/GetAll")
			.then((response) => response.json().then((data) => setForms(data.value)))
			.then((data) => console.log(data));
	}, []);

	const handleForm = () => {
		fetch("http://localhost:5202/api/Form/Create", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(
				`requestModel: {
          name: ${requestModel.name},
          description: ${requestModel.description},
          fields: ${requestModel.fields}
        }`
			),
		})
			.then((response) => response.json())
			.then((data) => console.log(data));
	};

	console.log(forms);
	console.log(isLogin);
	const router = useRouter();

	return (
		<>
			{isLogin === true ? (
				<>
					<div className="container mt-5">
						<div className="row">
							<div className="col-12">
								<div className="input-group">
									<input
										type="text"
										className="form-control"
										placeholder="Search"
										aria-label="Search"
										aria-describedby="basic-addon2"
									/>
									<div className="input-group-append">
										<button className="btn btn-outline-secondary" type="button">
											Search
										</button>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div className="container mt-5">
						<table className="table table-bordered table-hover">
							<thead className="thead-dark">
								<tr>
									<th scope="col">Form Adı</th>
									<th scope="col">Form Açıklaması</th>
									<th scope="col">Form Oluşturulma Tarihi</th>
									<th scope="col">Form Güncellenme Tarihi</th>
								</tr>
							</thead>
							<tbody className="table-light">
								{forms.map((form) => (
									<tr key={form.id}>
										<Link href={`/form/${form.id}`}>
											<td>{form.name}</td>
											<td>{form.description}</td>
											<td>{form.createDate}</td>
										</Link>
									</tr>
								))}
							</tbody>
						</table>
					</div>
					<div className="container mt-5">
						<div className="row">
							<div className="col-2 offset-10">
								<button
									type="button"
									className="btn bg-primary text-white"
									onClick={() => setShowPopup(true)}>
									Yeni Form Oluştur
								</button>
							</div>
						</div>
					</div>
				</>
			) : (
				<div className="d-flex align-items-center justify-content-center vh-100">
					Lütfen giriş yapınız
					<button onClick={() => router.push("/")}>Giriş Yap</button>
				</div>
			)}

			{showPopup && (
				<div className="fixed-top w-100 h-100 bg-dark">
					<div className="row">
						<div className="col-12">
							<div className="card">
								<div className="card-header bg-primary text-white">
									<h5 className="card-title">Yeni Form Oluştur</h5>
									<button
										type="button"
										className="close"
										aria-label="Close"
										onClick={() => setShowPopup(false)}>
										<span aria-hidden="true">&times;</span>
									</button>
								</div>
								<div className="card-body">
									<div>
										<div className="form-group">
											<label htmlFor="formName">Form Adı</label>
											<input
												type="text"
												className="form-control"
												id="formName"
												placeholder="Form Adı"
												onChange={(e) =>
													setRequestModel({
														...requestModel,
														name: e.target.value,
													})
												}
											/>
										</div>
										<div className="form-group">
											<label htmlFor="formDescription">Form Açıklaması</label>
											<textarea
												className="form-control"
												id="formDescription"
												rows={3}
												placeholder="Form Açıklaması"
												onChange={(e) =>
													setRequestModel({
														...requestModel,
														description: e.target.value,
													})
												}
											/>
										</div>
										<div className="form-group">
											{/* fields: [ { "required": true, "name": "Ad", dataType: "STRING" } böyle bir yapıya uygun girdi almalı */}
											<label htmlFor="formFields">Form Alanları</label>
											<textarea
												className="form-control"
												id="formFields"
												rows={3}
												placeholder="Form Alanları"
												onChange={(e) =>
													setRequestModel({
														...requestModel,
														fields: e.target.value,
													})
												}
											/>
										</div>
										<button
											type="submit"
											className="btn bg-primary text-white"
											onClick={handleForm}>
											Oluştur
										</button>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			)}
		</>
	);
};

export default Homepage;
