import { cookies } from "next/headers";
import { redirect } from "next/navigation";
import { API_URL } from "@/libs/constants";
import DeleteExerciseButton from "@/components/DeleteExerciseButton";

interface SavedExercise {
  exerciseId: number;
  name: string | null;
  muscle: string | null;
  sets: number | null;
  reps: number | null;
}

export default async function UserPage() {
  const cookieStore = await cookies();
  const userName = cookieStore.get("name")?.value;
  const token = cookieStore.get("token")?.value;

  if (!userName || !token) {
    redirect("/login");
  }

  const response = await fetch(`${API_URL}/api/user-exercises`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
    cache: "no-store",
  });

  if (response.status === 401) {
    redirect("/login");
  }

  const savedExercises = response.ok
    ? (await response.json() as SavedExercise[])
    : [];

  return (
    <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
      <div className="mx-auto max-w-5xl">
        <h1 className="text-3xl font-semibold">
          Welcome, {userName}
        </h1>

        <section className="mt-10">
          <h2 className="text-2xl font-semibold">Your saved sets and reps</h2>

          {savedExercises.length === 0 ? (
            <p className="mt-4 text-slate-400">
              You have not saved any exercises yet.
            </p>
          ) : (
            <div className="mt-6 grid gap-4 sm:grid-cols-2">
              {savedExercises.map((exercise) => (
                <article
                  key={exercise.exerciseId}
                  className="rounded-2xl border border-white/10 bg-white/[0.04] p-5 backdrop-blur-xl"
                >
                  <p className="text-sm text-sky-300">{exercise.muscle}</p>
                  <h3 className="mt-2 text-xl font-semibold">{exercise.name}</h3>
                  <p className="mt-4 text-slate-300">
                    {exercise.sets} sets x {exercise.reps} reps
                  </p>
                  <DeleteExerciseButton exerciseId={exercise.exerciseId} />
                </article>
              ))}
            </div>
          )}
        </section>
      </div>
    </main>
  );
}