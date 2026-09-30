import Link from "next/link";
import { notFound } from "next/navigation";
import ExerciseSetsRepsForm from "@/components/ExerciseSetsRepsForm";
import { getExerciseById } from "@/services/exerciseServices";
import { cookies } from "next/headers";

interface ExerciseDetailPageProps {
	params: Promise<{
		id: string;
	}>;
}

export default async function ExerciseDetailPage({ params }: ExerciseDetailPageProps) {
	const resolvedParams = await params;
	const exerciseId = Number(resolvedParams.id);
	
	const cookieStore = await cookies();
	const isLoggedIn = Boolean(cookieStore.get("token")?.value);

	if (Number.isNaN(exerciseId)) {
		notFound();
	}

	try {
		const exercise = await getExerciseById(exerciseId);

		return (
			<main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
				<div className="mx-auto max-w-xl">
					<Link
						href="/exercises"
						className="inline-block rounded-lg border border-white/20 bg-white/5 px-4 py-2 text-sm font-medium transition hover:bg-white/10"
					>
						Back to Exercises
					</Link>

					<div className="mt-6 rounded-2xl border border-white/10 bg-white/[0.03] p-5">
						<div className="mb-3 inline-flex rounded-full bg-slate-800 px-3 py-1 text-xs text-sky-200">
							{exercise.muscle}
						</div>
						<h1 className="text-3xl font-semibold">{exercise.name}</h1>
					</div>

					<div className="mt-4">
						<ExerciseSetsRepsForm
							exerciseId={exercise.id}
							initialSets={exercise.sets}
							initialReps={exercise.reps}
							isLoggedIn={isLoggedIn}
						/>
					</div>
				</div>
			</main>
		);
	} catch {
		return (
			<main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
				<div className="mx-auto max-w-xl">
					<h1 className="text-3xl font-semibold">Exercise</h1>
					<p className="mt-6 rounded-xl border border-rose-500/30 bg-rose-500/10 p-6 text-rose-100">
						Could not load exercise details. Please ensure the backend API is running.
					</p>
				</div>
			</main>
		);
	}
}
