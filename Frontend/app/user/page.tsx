import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default async function UserPage() {
  const cookieStore = await cookies();
  const userName = cookieStore.get("name")?.value;

  if (!userName) {
    redirect("/login");
  }

  return (
    <main className="min-h-screen bg-slate-950 px-6 py-16 text-slate-100">
      <div className="mx-auto max-w-5xl">
        <h1 className="text-3xl font-semibold">
          Welcome, {userName}
        </h1>
      </div>
    </main>
  );
}