import Link from "next/link";
import { getExercises, type MuscleGroup } from "@/services/exerciseServices";

const FILTER_GROUPS: Array<MuscleGroup | "All"> = [
  "All",
  "Chest",
  "Back",
  "Legs",
  "Arms",
  "Shoulders",
  "Core",
];

interface ExercisesPageProps {
  searchParams?: Promise<{
    group?: string;
  }>;
}

export default async function ExercisesPage({ searchParams }: ExercisesPageProps) {
  try {
    const params = (await searchParams) ?? {};
    const selectedGroup =
      FILTER_GROUPS.find((group) => group === params.group) ?? "All";

    const exercises = await getExercises();
    const filteredExercises =
      selectedGroup === "All"
        ? exercises
        : exercises.filter((exercise) => exercise.muscle.toLowerCase() === selectedGroup.toLowerCase());

    return (
      <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
        <div className="mx-auto max-w-5xl">
          <div className="mb-8 flex items-center justify-between gap-4">
            <h1 className="text-3xl font-semibold sm:text-4xl">Exercises</h1>
            <Link
              href="/"
              className="rounded-lg border border-white/20 bg-white/5 px-4 py-2 text-sm font-medium transition hover:bg-white/10"
            >
              Back Home
            </Link>
          </div>

          <div className="mb-8 flex flex-wrap gap-2">
            {FILTER_GROUPS.map((group) => {
              const isActive = group === selectedGroup;

              return (
                <Link
                  key={group}
                  href={group === "All" ? "/exercises" : `/exercises?group=${group}`}
                  className={`rounded-lg px-3 py-2 text-sm font-medium transition ${
                    isActive
                      ? "bg-sky-500 text-slate-950"
                      : "border border-white/20 bg-white/5 text-slate-200 hover:bg-white/10"
                  }`}
                >
                  {group}
                </Link>
              );
            })}
          </div>

          {filteredExercises.length === 0 ? (
            <p className="rounded-xl border border-white/10 bg-white/5 p-6 text-slate-300">
              No exercises found for this muscle group.
            </p>
          ) : (
            <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-3">
              {filteredExercises.map((exercise) => (
                <Link
                  key={exercise.id}
                  href={`/exercises/${exercise.id}`}
                  className="rounded-2xl border border-white/10 bg-white/[0.03] p-5 transition hover:border-white/20 hover:bg-white/[0.06]"
                >
                  <div className="mb-3 inline-flex rounded-full bg-slate-800 px-3 py-1 text-xs text-sky-200">
                    {exercise.muscle}
                  </div>
                  <h2 className="text-xl font-semibold">{exercise.name}</h2>
                </Link>
              ))}
            </div>
          )}
        </div>
      </main>
    );
  } catch {
    return (
      <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
        <div className="mx-auto max-w-5xl">
          <h1 className="text-3xl font-semibold sm:text-4xl">Exercises</h1>
          <p className="mt-6 rounded-xl border border-rose-500/30 bg-rose-500/10 p-6 text-rose-100">
            Could not load exercises. Please ensure the backend API is running.
          </p>
        </div>
      </main>
    );
  }
}
